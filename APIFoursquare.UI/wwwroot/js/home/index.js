'use strict';

let categorias = $('#categorias');

let map;
let infoWindow;
let markers = [];  
let pos = {
    lat: 19.04334,
    lng: -98.20193,
};

categorias.on('change', () => {
    for (let i = 0; i < markers.length; i++) {
        markers[i].setMap(null);
    }

    markers = [];

    Swal.fire({
        icon: 'info',
        title: 'Consultando lugares',
        text: 'Espera un momento, por favor...',
        showCancelButton: false,
        showCloseButton: false,
        showConfirmButton: false,
        allowOutsideClick: false,
        allowEscapeKey: false,
        allowEnterKey: false
    });

    obtenerLugares()
        .then((resultado) => {
            if (resultado.length > 0) {
                addMarker(resultado); 

                Swal.close();
            }
            else {
                Swal.fire({
                    icon: 'warning',
                    title: 'No se encontraron lugares',
                    text: 'No fue posible encontrar lugares cerca de la zona indicada',
                    confirmButtonText: 'ACEPTAR',
                    allowOutsideClick: false,
                    allowEscapeKey: false,
                    allowEnterKey: false
                });
            }
        })
        .catch((error) => {   
            if (error.responseText) {
                Swal.fire({
                    icon: 'error',
                    title: 'Ocurrió un error',
                    text: error.responseText,
                    confirmButtonText: 'ACEPTAR',
                    allowOutsideClick: false,
                    allowEscapeKey: false,
                    allowEnterKey: false
                });
            }
        });
})

let initMap = () => {
    map = new google.maps.Map(document.getElementById('map'), {
        mapId: '4684e1135be955f0',
        center: {
            lat: pos.lat,
            lng: pos.lng,
        },
        zoom: 15,
        maxZoom: 22,
        minZoom: 8,
        zoomControl: true,
        scrollwheel: false,
        disableDoubleClickZoom: false,
        streetViewControl: false,
        mapTypeControl: false,
        fullscreenControl: false,
    });

    infoWindow = new google.maps.InfoWindow();

    const locationButton = document.createElement("button");

    locationButton.textContent = "Obtener mi ubicación";
    locationButton.classList.add("custom-map-control-button");

    map.controls[google.maps.ControlPosition.TOP_RIGHT].push(
        locationButton
    );

    locationButton.addEventListener("click", () => {
        // Intentar obtener la geolocalización
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(
                (position) => {
                    pos = {
                        lat: position.coords.latitude,
                        lng: position.coords.longitude,
                    };

                    infoWindow.setPosition(pos);
                    infoWindow.setContent("Esta es tu ubicación actual.");
                    infoWindow.open(map);
                    map.setCenter(pos);
                },
                () => {
                    handleLocationError(true, infoWindow, map.getCenter());
                }
            );
        } else {
            // Ocurrió un error
            handleLocationError(false, infoWindow, map.getCenter());
        }
    });

    
};

let handleLocationError = (browserHasGeolocation, infoWindow, pos) => {
    infoWindow.setPosition(pos);
    infoWindow.setContent(
        browserHasGeolocation
            ? "Error: El servicio de localización falló."
            : "Error: Tu navegador no soporta la función de geolocalización."
    );
    infoWindow.open(map);
};

let addMarker = (lugares) => {
    $.each(lugares, (i, v) => {
        let imagenes = '';

        if (v.fotosLugar[0]) {
            $.each(v.fotosLugar, (ii, iv) => {
                imagenes += `
                    <div class="carousel-item${ii === 0 ? ' active' : ''}">
                        <img class="d-block w-100" src="${iv.urlBase}350x350${iv.archivo}" alt="Foto ${ii + 1}">
                    </div>`;
            });
        }
        else {
            imagenes = `
                <div class="carousel-item active">
                    <img class="d-block w-100" src="../../img/default-image_450.png" alt="Foto no existente">
                </div>`;
        }

        let content =
            `<h6 class="titulo-mapa" id="nombre_${v.id}">${v.nombre}</h6>
            <div id="carousel_${v.id}" class="carousel slide" data-ride="carousel">
                <div class="carousel-inner">
                    ${imagenes}
                </div>
            </div>
            <label class="puntuacion-mapa">Puntuación: <b id="puntuacion_${v.id}">${v.puntuacion}</b></label>
            <label class="direccion-mapa" id="direccion_${v.id}">${v.direccion.calle}</label>
            <button onclick="guardarFavorito('${v.id}', ${v.geocodes.main.latitud}, ${v.geocodes.main.longitud})" class="boton-mapa">Agregar a favoritos</button>`;
        
        let marker = new google.maps.Marker({
            position: {
                lat: v.geocodes.main.latitud,
                lng: v.geocodes.main.longitud,
            },
            map,
            title: v.nombre,
            animation: google.maps.Animation.DROP,
        });

        markers.push(marker);

        marker.addListener('click', function () {
            if (infoWindow) infoWindow.close();

            infoWindow = new google.maps.InfoWindow({
                content: content,
                ariaLabel: v.nombre,
            });

            infoWindow.open({
                anchor: marker,
                map,
            }); 

            google.maps.event.addListener(infoWindow, 'domready', function () {
                // El contenido del InfoWindow se ha cargado completamente, en este punto se puede iniciar el carrusel
                $('#map div.carousel').carousel(0);
                $('#map div.carousel').carousel({
                    interval: 100
                });
            });
        });

        map.addListener("click", function () {
            infoWindow.close();
        });
    });
};

const obtenerCategorias = () => {
    return new Promise((resolve, reject) => {
        $.ajax({
            method: 'GET',
            url: '/Home/ObtenerCategorias',
            success: resolve,
            error: reject
        });
    });
};

const obtenerLugares = () => {
    return new Promise((resolve, reject) => {
        $.ajax({
            method: 'GET',
            url: '/Home/ObtenerLugares',
            data: {
                categoria: categorias.val(),
                latitud: pos.lat,
                longitud: pos.lng
            },
            success: resolve,
            error: reject
        });
    });
};

const agregarFavorito = (modelo) => {
    return new Promise((resolve, reject) => {
        $.ajax({
            method: 'POST',
            url: '/Lugares/GuardarFavorito',
            data: { modelo },
            success: resolve,
            error: reject
        });
    });
};

const guardarFavorito = (id, lat, lng) => {
    let modelo = {
        idLugar: id,
        idCategoria: categorias.val(),
        nombre: $(`#nombre_${id}`).html(),
        puntuacion: $(`#puntuacion_${id}`).html(),
        direccion: $(`#direccion_${id}`).html(),
        latitud: lat,
        longitud: lng
    };

    agregarFavorito(modelo)
        .then((resultado) => {
            Swal.fire({
                icon: 'info',
                title: 'Lugar guardado',
                text: `${modelo.nombre} se agregó a tus favoritos`,
                confirmButtonText: 'ACEPTAR',
                allowOutsideClick: false,
                allowEscapeKey: false,
                allowEnterKey: false
            });
        })
        .catch((error) => {
            Swal.fire({
                icon: 'error',
                title: 'Ocurrió un error',
                text: error.responseText,
                confirmButtonText: 'ACEPTAR',
                allowOutsideClick: false,
                allowEscapeKey: false,
                allowEnterKey: false
            });
        });
}

obtenerCategorias()
    .then((resultado) => {
        categorias.empty();
        categorias.append(`<option value="none" selected disabled>Selecciona una opción</option>`);

        $.each(resultado, (i, v) => {
            categorias.append(`<option value="${v.categoriaId}">${v.nombreCategoria}</option>`)
        });
    })
    .catch((error) => {
        Swal.fire({
            icon: 'error',
            title: 'Ocurrió un error',
            text: error.responseText,
            confirmButtonText: 'ACEPTAR',
            allowOutsideClick: false,
            allowEscapeKey: false,
            allowEnterKey: false
        });
    });

window.initMap = initMap;    