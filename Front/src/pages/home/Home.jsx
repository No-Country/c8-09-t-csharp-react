import { useEffect, useState } from "react";
import SeccionEvent from "../../components/nextEvents/SeccionEvent";


const Home = () => {

	const [events, setEvents] = useState([])

    const eventsFetch = async () => {
        const response = await fetch("https://635eb27203d2d4d47af47b8b.mockapi.io/Cohorte")
        const data = await response.json()
        setEvents([data[0], data[1], data[2]])
    }

    useEffect(()=> {
        eventsFetch()
    }, [])


	return (
		<div>
			<SeccionEvent seccion={"Proximos eventos"} eventos={events}/>
		</div>
	)
}

export default Home
