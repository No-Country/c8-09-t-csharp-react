import { useEffect, useState } from 'react'
import SeccionEvent from '../../components/seccionEvents/SeccionEvent'
import Newsletter from '../../components/Newsletter/Newsletter'
import Footer from '../../components/footer/Footer'
import Comments from '../../components/Comments/Comments'
import Carousel from '../../components/Carousel/Carousel'
import TopVendidos from '../../components/TopVendidos/TopVendidos'

const Home = () => {
	return (
		<div>
			<Carousel />
			<SeccionEvent seccion={'Proximos eventos'} ruta={"/"}/>
			<TopVendidos/>
			<Comments />
			<SeccionEvent seccion={'Lo mas buscado'} ruta={"/"}/>
			<Newsletter />
			<Footer />
		</div>
	)
}

export default Home
