import style from './Newsletter.module.css'
import axios from 'axios'
import rejectionImg from '/rejection.svg'
import responseImg from '/response.svg'
import { Alert } from '../../utils/alert'

const Newsletter = () => {
	const handleSubmit = async e => {
		e.preventDefault()
		const body = { email: e.target[0].value }
		try {
			await axios.post(
				'https://cohorteapi.azurewebsites.net/api/Newsletter/subscribe',
				body
			)
			Alert.fire({
				title: '¡Bien hecho!',
				html: `Te has subscripto correctamente con el correo: </br> <b>${body.email}</b>`,
				imageUrl: responseImg,
				imageAlt: 'confirm',
				confirmButtonText: `<button class="botonPrincipal" >Ok</button>`,
			})
		} catch (error) {
			return await Alert.fire({
				title: 'Ooops',
				html: `Ha ocurrido un error </br> Por favor inténtenlo nuevamente`,
				imageUrl: rejectionImg,
				imageAlt: 'error',
				confirmButtonText: `<button class="botonPrincipal" >Volver a intentar</button>`,
			})
		}
	}
	return (
		<div className={style.newsletter}>
			<h5 className={style.newsletterTitle}>
				Suscribete a nuestro newsletter y no te pierdas tus artistas favoritos.
			</h5>
			<form className={style.form} onSubmit={handleSubmit}>
				<input
					name='email'
					className={style.formInput}
					type='email'
					placeholder='Email'
					required
				/>
				<button className={style.formButton}>Suscribirme</button>
			</form>
		</div>
	)
}

export default Newsletter
