import "./listEvents.css"
import CardEvent from "../cardEvent/CardEvent.jsx"
import {useDispatch, useSelector} from "react-redux"
import { getEvents } from "../../redux/actions"
import { useEffect, useState } from "react"

const ListEvents = () => {

    const dispatch = useDispatch();
    const events = useSelector(state => state.allEvents)

    useEffect(()=>{
        dispatch(getEvents())
    }, [])

    return(
        <div className="containerEventos">
            <div className="listaEventos">
                {events.data?.map((event)=> <CardEvent key={event.id} evento={event}/>)}
            </div>
        </div>
       
    )
}

export default ListEvents;