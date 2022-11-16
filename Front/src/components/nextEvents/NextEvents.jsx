import "./nextEvents.css"
import { useEffect, useState } from "react";
import ListEvents from "../listEvents/ListEvents";
import {Link} from "react-router-dom"

const NextEvents = () => {

    const [events, setEvents] = useState([])

    const eventsFetch = async () => {
        const response = await fetch("https://635eb27203d2d4d47af47b8b.mockapi.io/Cohorte")
        const data = await response.json()
        setEvents([data[0], data[1], data[2]])
    }

    useEffect(()=> {
        eventsFetch()
    }, [])

    return(
        <div className="containerNext">
            <div className="titulo">
                <h3>Proximos eventos</h3>
                <Link>Ver mas eventos {">"}</Link>
            </div>
            <div className="eventos">
                <ListEvents eventos={events}/>
            </div>
        </div>
    )
}

export default NextEvents;