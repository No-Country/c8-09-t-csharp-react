import Swal from 'sweetalert2';


export const Alert = Swal.mixin({
    imageWidth: 100,
    imageHeight: 100,
    imageAlt: 'icon',
    confirmButtonColor: '#FC4A88',
    width: '31.5rem',
    buttonsStyling: false,
    backdrop: true,
    allowOutsideClick: false,
    allowEscapeKey: false,
    allowEnterKey: false,
    stopKeydownPropagation: false
})