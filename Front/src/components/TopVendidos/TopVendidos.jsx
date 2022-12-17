import "./topVendidos.css"
import { useSelector } from "react-redux"
import { Link } from "react-router-dom"
import { useEffect, useState } from "react"
import axios from "axios"


const TopVendidos = () => {

    const [topVendidos, setTopVendidos] = useState([])

    const getVendidos = async () => {
        const response = await axios.get("https://cohorteapi.azurewebsites.net/api/Events/TopEvents")
        setTopVendidos(response.data)
    }

    useEffect(()=>{
        getVendidos()
    }, [])


    const events = useSelector(state => state.allEventsCopy)

    return(
        <div className="vendidosContainer">
                <h1>Top mas vendidos</h1>
                <div className="topVendidos">
                    {topVendidos.map((event, index)=>{
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
        </div>
    )
}

export default TopVendidos