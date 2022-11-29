import './cardEvent.css'
import { Link } from 'react-router-dom'

const CardEvent = ({ evento }) => {
	const meses = [
		'',
		'Ene',
		'Feb',
		'Mar',
		'Abr',
		'May',
		'Jun',
		'Jul',
		'Ago',
		'Sept',
		'Oct',
		'Nov',
		'Dic',
	]
	const description = evento.eventDescription.slice(0, 20)
	const fechaSinFormatear = evento.eventTime.slice(0, 10)
	const fecha = fechaSinFormatear.split('-')
	const horario = evento.eventTime.slice(11, 16)

	return (
		<div className='cardEvento'>
			<img className='cardImagen' src={evento.frontPageImage} alt={evento.eventName} />
			<div className='infoEvento'>
				<div className='containerInfo'>
					<div className='fechaHoraContainer'>
						<h3 className='fecha'> {fecha[2]} </h3>
						<div className='mesHora'>
							<h3>
								{' '}
								{meses[fecha[1]]}, {fecha[0]}{' '}
							</h3>
							<h4> {horario} </h4>
						</div>
					</div>
					<div className='eventoArtista'>
						<h2> {evento.eventName} </h2>
						<h4> {description} </h4>
					</div>
				</div>
				<div className='containerBotones'>
					<Link to={'/'}> Saber mas </Link>
					<Link to={'/'}>
						<div className='buttonComprar'>
							<span>Comprar ahora</span>
						</div>
					</Link>
				</div>
			</div>
		</div>
	)
}

export default CardEvent
