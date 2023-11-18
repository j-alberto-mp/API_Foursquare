let lugares = $('#lugares');

const obtenerLugares = () => {
    return new Promise((resolve, reject) => {
        $.ajax({
            method: 'GET',
            url: '/Lugares/ObtenerFavoritos',
            success: resolve,
            error: reject
        });
    });
};

obtenerLugares()
    .then((resultado) => {
        lugares.empty();
        $.each(resultado, (ci, cv) => {
            let favoritos = '';

            $.each(cv.favoritos, (fi, fv) => {
                let imagenes = '';

                if (fv.fotosLugar[0]) {
                    $.each(fv.fotosLugar, (ii, iv) => {
                        imagenes += `
                        <div class="carousel-item ${ii === 0 ? 'active' : ''}">
                            <img class="d-block w-100" src="${iv.urlBase}350x350${iv.archivo}" alt="Foto ${ii + 1}">
                        </div>`;
                    });
                }
                else {
                    imagenes = `
                        <div class="carousel-item active">
                            <img class="d-block w-100" src="../../img/default-image_450.png" alt="Foto no existente">
                        </div>`
                }

                favoritos += `
                <div class="col-6 col-md-3 col-md-4 col-lg-3">
                    <div class="card">
                        <div id="carousel_${fv.idLugar}" class="carousel slide" data-ride="carousel">
                            <div class="carousel-inner">
                                ${imagenes}
                            </div>
                        </div>
                        <div class="card-body">
                            <h5 class="card-title">${fv.nombre}</h5>
                            <p class="card-subtitle mb-2 text-muted">${fv.puntuacion}</p>
                            <p class="card-text">${fv.direccion}</p>
                        </div>
                    </div>
                </div>
                `
            });

            lugares.append(
                `<h2>${cv.categoria}</h2>
                <div class="row">${favoritos}</div>`
            );  
        });
    })
    .then(() => {
        $('.carousel').carousel(0);
        $('.carousel').carousel({
            interval: 100
        })
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