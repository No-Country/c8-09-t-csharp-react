import "./topVendidos.css"
import { useSelector } from "react-redux"
import { Link } from "react-router-dom"

const TopVendidos = () => {

    const events = useSelector(state => state.allEventsCopy)

    return(
        <div className="vendidosContainer">
                <h1>Top mas vendidos</h1>
                {events.data === undefined ? 
                <div className="topVendidos">
                    {events.map((event, index)=>{
                        return(
                        <div key={index} className="img" style={{backgroundImage: `url(${event.frontPageImage})`}}>
                            <div className="info">
                                <h1> {event.eventName} </h1>
                                <h2> {event.venue} </h2>
                                <Link to={`/event/${event.id}`} className="buttonInfo">Mas informacion</Link>
                            </div>
                        </div>
                        )
                    })}
                </div>
            :
                <div className="topVendidos">
                    {events.data?.map((event, index)=> {
                        return(
                            <div key={index} className="img" style={{backgroundImage: `url(${event.frontPageImage})`}}>
                                <div className="info">
                                    <h1> {event.eventName} </h1>
                                    <h2> {event.venue} </h2>
                                    <Link to={`/event/${event.id}`} className="buttonInfo">Mas informacion</Link>
                                </div>
                            </div>
                            )
                    })}
                </div>
                }       
                <div className="topVendidos">
                    
                    {/* <div className="img" style={{backgroundImage: `url(/imagen-larga.png)`}}>
                        <div className="info">
                            <h1>Festival de todo lo que nos hace bien</h1>
                            <h2>Hipodromo de palermo</h2>
                            <button className="buttonInfo">Mas informacion</button>
                        </div>
                    </div>
                    <div className="img" style={{backgroundImage: `url(/imagen-larga.png)`}}>
                            <div className="info">
                                <h1>Festival de todo lo que nos hace bien</h1>
                                <h2>Hipodromo de palermo</h2>
                                <button className="buttonInfo">Mas informacion</button>
                            </div>
                    </div>
                    <div className="img" style={{backgroundImage: `url(/imagen-larga.png)`}}>
                            <div className="info">
                                <h1>Festival de todo lo que nos hace bien</h1>
                                <h2>Hipodromo de palermo</h2>
                                <button className="buttonInfo">Mas informacion</button>
                            </div>
                    </div> */}
                </div>
        </div>
    )
}

export default TopVendidos