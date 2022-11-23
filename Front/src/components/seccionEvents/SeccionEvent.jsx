import "./seccionEvents.css"
import ListEvents from "../listEvents/ListEvents";
import {Link} from "react-router-dom"

const SeccionEvent = ({seccion, eventos, ruta}) => {
    return(
        <div className="containerNext">
            <div className="titulo">
                <h3>{seccion}</h3>
                <Link to={ruta}>Ver mas eventos {">"}</Link>
            </div>
            <div className="eventos">
                <ListEvents eventos={eventos}/>
            </div>
        </div>
    )
}

export default SeccionEvent;