import { useEffect, useState } from 'react'
import SeccionEvent from '../../components/seccionEvents/SeccionEvent'
import Newsletter from '../../components/Newsletter/Newsletter'
import Footer from '../../components/footer/Footer'
import Comments from '../../components/Comments/Comments'
import Carousel from '../../components/Carousel/Carousel'
import TopVendidos from '../../components/TopVendidos/TopVendidos'

const Home = () => {
	const [events, setEvents] = useState([])
	const eventos = events.slice(0, 5)

	const eventsFetch = async () => {
		const response = await fetch(
			'https://635eb27203d2d4d47af47b8b.mockapi.io/Cohorte'
		)
		const data = await response.json()
		setEvents(data.slice(0, 4))
	}

	useEffect(() => {
		eventsFetch()
	}, [])

	return (
		<div>
			<Carousel />
			<SeccionEvent seccion={'Proximos eventos'} eventos={events} ruta={"/"}/>
			<TopVendidos/>
			<Comments />
			<SeccionEvent seccion={'Lo mas buscado'} eventos={events} ruta={"/"}/>
			<Newsletter />
			<Footer />
		</div>
	)
}

export default Home
