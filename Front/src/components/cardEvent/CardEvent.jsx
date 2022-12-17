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
	//const name = evento.eventName.slice(0, 30)
	const fechaSinFormatear = evento.eventTime.slice(0, 10)
	const fecha = fechaSinFormatear.split('-')
	const horario = evento.eventTime.slice(11, 16)

	return (
		<div className='cardEvento'>
			<div className='cardImg' style={{backgroundImage: `url(${evento.frontPageImage})`}}></div>
			<div className='infoEvento'>
				<div className='containerInfo'>
					<div className='fechaHoraContainer'>
						<h3 className='fecha'> {fecha[2]} </h3>
						<div className='mesHora'>
							<h3>
								{' '}
								{meses[fecha[1]] || "Dic"}, {fecha[0]}{' '}
							</h3>
							<h4> {horario} </h4>
						</div>
					</div>
					<div className='eventoArtista'>
						<h2> {evento.eventName} </h2>
					</div>
				</div>
				<div className='containerBotones'>
					<Link to={`/event/${evento.id}`}>
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
