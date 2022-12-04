import style from './Checkout.module.css'

const Checkout = () => {
	const tarjeta = {
		titular: 'Maxi Martins',
		numero: '1231 4324 9403 2345 0101',
		mes: 'Enero',
		año: '2025',
		cvv: '123',
	}
	const detalleCompra = {
		evento: 'La última vuelta world tour',
		ubicacion: 'Platea Central',
		cantidad: 2,
		total: 2000,
	}

	return (
		<div className={style.checkout}>
			<div className={style.leftContainer}>
				<img className={style.bgImg} src='./dyank.png' alt='img-checkoout' />
				<div className={style.detailTicket}>
					<div className={style.detailEvent}>
						<div className={style.detailEventColum}>
							<h5>Evento</h5>
							<span>{detalleCompra.evento}</span>
						</div>
						<div className={style.detailEventColum}>
							<h5>Ubicación</h5>
							<span>{detalleCompra.ubicacion}</span>
						</div>
						<div className={style.detailEventColum}>
							<h5>Cantidad</h5>
							<span>{detalleCompra.cantidad} entradas</span>
						</div>
						<div className={style.detailEventTotal}>
							<span>Total: ${detalleCompra.total}</span>
						</div>
					</div>
				</div>
			</div>
			<div className={style.rightContainer}>
				<h2 className={style.rightContainerTitle}>Detalle de pago</h2>
				<div className={style.rightContainerData}>
					<h5 className={style.dataTitle}>TITULAR DE TARJETA</h5>
					<span className={style.dataSubTitle}>{tarjeta.titular}</span>
					<h5 className={style.dataTitle}>NÚMERO DE TARJETA</h5>
					<span className={style.dataSubTitle}>
						{formatearNum(tarjeta.numero)}
					</span>
					<div className={style.dataTarjeta}>
						<div className={style.dataTarjetaVenc}>
							<h5 className={style.dataTitle}>FECHA DE VENCIMIENTO</h5>
							<select name='mes' id='mes'>
								{mes.map(elem => (
									<option key={elem} value={elem}>
										{elem}
									</option>
								))}
							</select>
							<select name='mes' id='mes'>
								{año.map(elem => (
									<option key={elem} value={elem}>
										{elem}
									</option>
								))}
							</select>
						</div>
						<div className={style.dataTarjetaCVV}>
							<h5 className={style.dataTitle}>CVV</h5>
							<input
								className={style.tarjetaPassword}
								type='password'
								placeholder='***'
								maxLength={'3'}
							/>
						</div>
					</div>
					<div className={style.rightContainerButtons}>
						<button className={style.rightContainerButtonCancel}>
							Cancelar
						</button>
						<button className={style.rightContainerButtonBuy}>
							Comprar ahora
						</button>
					</div>
				</div>
			</div>
		</div>
	)
}

const formatearNum = ele => {
	return ele
		.split(' ')
		.map((ele, index) => (index === 2 || index === 3 ? '****' : ele))
		.join(' ')
}

const año = [
	'2019',
	'2020',
	'2021',
	'2022',
	'2023',
	'2024',
	'2025',
	'2026',
	'2027',
	'2028',
	'2029',
	'2030',
]
const mes = [
	'Enero',
	'Febrero',
	'Marzo',
	'Abril',
	'Mayo',
	'Junio',
	'Julio',
	'Agosto',
	'Septiembre',
	'Octubre',
	'Noviembre',
	'Diciembre',
]
export default Checkout
