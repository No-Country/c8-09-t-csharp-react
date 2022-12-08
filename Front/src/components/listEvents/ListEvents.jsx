import "./listEvents.css"
import CardEvent from "../cardEvent/CardEvent.jsx"
import {useSelector} from "react-redux"

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