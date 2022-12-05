import "./listEvents.css"
import CardEvent from "../cardEvent/CardEvent.jsx"
import {useDispatch, useSelector} from "react-redux"
import { getEvents } from "../../redux/actions"
import { useEffect, useState } from "react"

const ListEvents = () => {

    const events = useSelector(state => state.allEventsCopy)

    return(
        <div className="containerEventos">
            {events.data === undefined ? 
                <div className="listaEventos">
                    {events.map((event)=> <CardEvent key={event.id} evento={event}/>)}
                </div>
            :
                <div className="listaEventos">
                    {events.data?.map((event)=> <CardEvent key={event.id} evento={event}/>)}
                </div>
        }
        </div>
       
    )
}

export default ListEvents;