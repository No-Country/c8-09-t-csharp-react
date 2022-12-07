import { useParams } from "react-router-dom";
import axios from 'axios'
import { useState } from "react";
import { useEffect } from "react";
import "./event.css"
import SeccionEvent from '../../components/seccionEvents/SeccionEvent'
import Footer from '../../components/footer/Footer'

//Tailwind components
import { Menu } from '@headlessui/react'
import { ChevronDownIcon } from '@heroicons/react/20/solid'
import Reviews from "../../components/Reviews/Reviews";
import dropdown from './dropdown.jsx'
const Event = () => {

    const [event, setEvent] = useState({})
    const [total, setTotal] = useState(0)
    const { id } = useParams()

    const getEvent = async () => {
        const response = await axios.get(`https://cohorteapi.azurewebsites.net/api/Events/${id}`)
        setEvent(response.data)
        dispatch(filterByGenres(response.data.category.name))
        console.log(response.data)
    }   

    useEffect(()=>{
        getEvent()
        console.log(event)
    }, [])

    return(
        
        <div>
            <div className="imageHeader" style={{backgroundImage: `url(${event.frontPageImage})`}}></div>
            <div className="eventInfo">
                <h1> {event.eventName} </h1>
                <h3> {event.eventDescription} </h3>
            </div>
            <div className="escenario">
                <h2>Sectores y precios</h2>
                <img src={`/${event.category?.name}.png`} alt={event.category?.name} />
            </div>
            <div className="eleccion">
                <form className="opciones">
                    <div className="select">
                        <label htmlFor="Ubicacion y precio">Ubicacion y precio</label>
                        <select name="Ubicacion y precio">
                            {event.sections?.map((s, index)=>{
                                return(
                                    <option key={index} value={s.name}> {s.name} ${s.price} </option>
                                )
                            })}
                        </select>
                    </div>
                    <div className="select">
                        <label htmlFor="Cantidad">Cantidad</label>
                        <select name="Cantidad" aria-label="Cantidad">
                            <option value="1">1</option>
                            <option value="1">2</option>
                            <option value="1">3</option>
                            <option value="1">4</option>
                            <option value="1">5</option>
                        </select>
                    </div>
                    <div className="totalContainer">
                        <h5>Precio total</h5>
                        <div className="total">
                            <h5>${total}</h5>
                        </div>
                    </div>
                    <input className="buttonComprar" type="submit" value="Comprar"/>
                </form>
            </div>
            <Reviews />
            <SeccionEvent seccion={"Te puede interesar"} ruta={"/"} />
            <Footer />
        </div>
    )
}

export default Event;
