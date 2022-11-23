import style from './Newsletter.module.css'
import axios from 'axios'

const Newsletter = () => {
	const handleSubmit = e => {
		e.preventDefault()
		const body = { email: e.target[0].value }
		return axios
			.post(
				'https://cohorteapi.azurewebsites.net/api/Newsletter/subscribe',
				body
			)
			.then(response => alert(JSON.stringify(response.data))) //CAMBIAR ESTO POR ALGUNA LIBRERIA DE ALERTAS
			.catch(error => alert(error))
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
