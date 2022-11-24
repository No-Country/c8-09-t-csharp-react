// import { Alert } from "../../utils/alert";
// import rejectionImg from '../../../public/rejection.svg'
// import responseImg from '../../../public/response.svg'

//// utilizarlo en el then
// Alert.fire({
//     title: '¡Listo! Revisar tu correo',
//     html: `Las instrucciones fueron enviadas a: </br> <b>${email}</b>`,
//     imageUrl: responseImg,
//     imageAlt: 'confirm',
//     confirmButtonText: `<button class="botonPrincipal" >Iniciar sesion</button>`,
// })
//// utilizarlo en el catch
// Alert.fire({
//     title: 'Ooops',
//     html: `No hay ninguna cuenta de usuario asignada al correo: </br> <b>${email}</b>`,
//     imageUrl: rejectionImg,
//     imageAlt: 'error',
//     confirmButtonText: `<button class="botonPrincipal" >Intentar de nuevo</button>`,
// })

const ForgotPassword = function () {
	return (
		<div>
			<h1>Reset your password here!</h1>
		</div>
	)
}

export default ForgotPassword
