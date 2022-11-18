import style from './Newsletter.module.css'

const Newsletter = () => {
	return (
		<div className={style.newsletter}>
			<h5 className={style.newsletterTitle}>
				Suscribete a nuestro newsletter y no te pierdas tus artistas favoritos.
			</h5>
			<form className={style.form} action=''>
				<input className={style.formInput} type='email' placeholder='Email' />
				<button className={style.formButton} type='submit'>
					Suscribirme
				</button>
			</form>
		</div>
	)
}

export default Newsletter
