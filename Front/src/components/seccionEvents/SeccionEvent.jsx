import "./seccionEvents.css"
import ListEvents from "../listEvents/ListEvents";
import {Link} from "react-router-dom"

const SeccionEvent = ({seccion, eventos}) => {
    return(
        <div className="containerNext">
            <div className="titulo">
                <h3>{seccion}</h3>
                <Link>Ver mas eventos {">"}</Link>
            </div>
            <div className="eventos">
                <ListEvents eventos={eventos}/>
            </div>
        </div>
    )
}

export default SeccionEvent;