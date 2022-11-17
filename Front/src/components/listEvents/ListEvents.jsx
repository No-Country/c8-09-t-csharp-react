import "./listEvents.css"
import CardEvent from "../cardEvent/CardEvent.jsx"

const ListEvents = ({eventos}) => {

    return(
        <div className="containerEventos">
            <div className="listaEventos">
                {eventos.map((event)=> <CardEvent key={event.id} evento={event}/>)}
            </div>
        </div>
       
    )
}

export default ListEvents;