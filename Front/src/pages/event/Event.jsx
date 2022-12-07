import { useParams } from "react-router-dom";
import axios from 'axios'
import { useState } from "react";
import { useEffect } from "react";
import "./event.css"
import SeccionEvent from '../../components/seccionEvents/SeccionEvent'
import Footer from '../../components/footer/Footer'
import { useDispatch, useSelector } from "react-redux";
import { filterByGenres, eventDetails } from "../../redux/actions";

//Tailwind components
import { Menu } from '@headlessui/react'
import { ChevronDownIcon } from '@heroicons/react/20/solid'
import Reviews from "../../components/Reviews/Reviews";
import dropdown from './dropdown.jsx'
const Event = () => {

    const dispatch = useDispatch()
    const event = useSelector(state => state.singleEventDetail)
    const [total, setTotal] = useState(0)
    const { id } = useParams()

    const [input, setInput] = useState({
       section: "",
       price: 0,
       quantity: 1
    })

    // const getEvent = async () => {
    //     const response = await axios.get(`https://cohorteapi.azurewebsites.net/api/Events/${id}`)
    //     setEvent(response.data)
    //     // dispatch(filterByGenres(response.data.category.name))
    //     // console.log(response.data)
    // }   

    // let filtered = await event.sections.filter(e => e.name === e.target.name)[0]
    function handleInput(e){
        let pr = parseInt(document.getElementById("sectionPrice").innerText)
        setInput({
            ...input,
            price: pr,
            [e.target.name]: e.target.value,
        })

        setTotal(input.price * parseInt(input.quantity))
    }


    useEffect(()=>{
        dispatch(eventDetails(id))
    }, [dispatch, id])

    function getSections(sectionArray){

        let eventSections = sectionArray.map(e => e.name)
  
        let obj = {};
        for (const key of eventSections) {
            obj[key] = {
               price: 0,
               quantity: 0
             };
        }
       
       return obj
     }


    function count(){
        let amount = []
        for(let i = 1; i < 11; i++){
            amount.push(
                <option key={i} value={i} name="quantity">{i}</option>
            )
        }
        return amount
    }

    console.log(input)
    console.log(total)


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
                        <select name="section" onChange={e => handleInput(e)}>
                            {event.sections?.map((s, index)=>{
                                return(
                                    <option key={index} value={s.name}> {s.name}  <p id="sectionPrice">{s.price}</p> </option>
                                )
                            })}
                        </select>
                    </div>
                    <div className="select">
                        <label htmlFor="Cantidad">Cantidad</label>
                        <select name="quantity" aria-label="Cantidad" onChange={e => handleInput(e)}>
                            {count()}
                            {/* <option value="1">1</option>
                            <option value="1">2</option>
                            <option value="1">3</option>
                            <option value="1">4</option>
                            <option value="1">5</option> */}
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