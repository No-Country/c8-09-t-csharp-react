import "./seccionEvents.css"
import ListEvents from "../listEvents/ListEvents";
import {Link} from "react-router-dom"

const SeccionEvent = ({seccion, ruta}) => {
    return(
        <div className="containerNext">
            <div className="titulo">
                <h3>{seccion}</h3>
                <Link to={ruta}>Ver mas {">"}</Link>
            </div>
            <div className="eventos">
                <ListEvents/>
            </div>
        </div>
    )
}

export default SeccionEvent;