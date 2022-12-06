import { useParams } from "react-router-dom";
import axios from 'axios'
import { useState } from "react";
import { useEffect } from "react";
import "./event.css"
import SeccionEvent from '../../components/seccionEvents/SeccionEvent'
import Footer from '../../components/footer/Footer'
import {useDispatch, useSelector} from "react-redux"
import { filterByGenres } from "../../redux/actions";
//Tailwind components
import { Menu } from '@headlessui/react'
import { ChevronDownIcon } from '@heroicons/react/20/solid'
import Reviews from "../../components/Reviews/Reviews";

const Event = () => {

    const [event, setEvent] = useState({})
    const [total, setTotal] = useState(0)
    const { id } = useParams()
    
    const dispatch = useDispatch();

    const ubicacion = ["Platea izquierda", "Platea central", "Platea derecha", "Palco izquierdo", "Palco derecho"]
    const cantidad = [ 1,2,3,4,5]

    const getEvent = async () => {
        const response = await axios.get(`https://cohorteapi.azurewebsites.net/api/Events/${id}`)
        setEvent(response.data)
        dispatch(filterByGenres(response.data.category.name))
    }   

    useEffect(()=>{
        getEvent()
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
                <img src="/esquema-escenario.png" alt="esquema-escenario" />
            </div>
            <div className="eleccion">
                <div className="opciones">
                            <Menu as="div" className="relative inline-block text-left">
                                <div>
                                    <Menu.Button className="inline-flex w-full justify-center bg-transparent border-gray-600 border-solid border-2 px-4 py-2 text-sm font-medium text-white shadow-sm hover:bg-pink-800">
                                    Precio
                                    <ChevronDownIcon className="-mr-1 ml-2 h-5 w-5" aria-hidden="true" />
                                    </Menu.Button>
                                </div>
                                <Menu.Items className="absolute right-0 z-10 mt-2 w-56 origin-top-right bg-transparent shadow-lg ring-1 ring-black ring-opacity-5 focus:outline-none">
                                    <div className="py-1">
                                            <Menu.Item>
                                                <a
                                                href="#"
                                                className={'bg-gray-800 border-gray-600 border-solid border-2 text-white block px-4 py-2 text-md font-semibold'}
                                                >
                                                ${event.price}
                                                </a>
                                            </Menu.Item>
                                    </div>
                                </Menu.Items>
                            </Menu>
                            <Menu as="div" className="relative inline-block text-left">
                                <div>
                                    <Menu.Button className="inline-flex w-full justify-center bg-transparent border-gray-600 border-solid border-2 px-4 py-2 text-sm font-medium text-white shadow-sm hover:bg-pink-800">
                                    Ubicacion
                                    <ChevronDownIcon className="-mr-1 ml-2 h-5 w-5" aria-hidden="true" />
                                    </Menu.Button>
                                </div>
                                <Menu.Items className="absolute right-0 z-10 mt-2 w-56 origin-top-right bg-transparent shadow-lg ring-1 ring-black ring-opacity-5 focus:outline-none">
                                    <div className="py-1">
                                            {ubicacion.map((u, index)=>{
                                                return(
                                                <Menu.Item key={index}>
                                                    <a
                                                    href="#"
                                                    className={'bg-gray-800 border-gray-600 border-solid border-2 text-white block px-4 py-2 text-md font-semibold'}
                                                    >
                                                    {u}
                                                    </a>
                                                </Menu.Item>
                                                )
                                            })}
                                            
                                    </div>
                                </Menu.Items>
                            </Menu>
                            <Menu as="div" className="relative inline-block text-left">
                                <div>
                                    <Menu.Button className="inline-flex w-full justify-center bg-transparent border-gray-600 border-solid border-2 px-4 py-2 text-sm font-medium text-white shadow-sm hover:bg-pink-800">
                                    Cantidad
                                    <ChevronDownIcon className="-mr-1 ml-2 h-5 w-5" aria-hidden="true" />
                                    </Menu.Button>
                                </div>
                                <Menu.Items className="absolute right-0 z-10 mt-2 w-56 origin-top-right bg-transparent shadow-lg ring-1 ring-black ring-opacity-5 focus:outline-none">
                                    <div className="py-1">
                                            {cantidad.map((c, index)=>{
                                                return(
                                                <Menu.Item key={index}>
                                                    <a
                                                    href="#"
                                                    className={'bg-gray-800 border-gray-600 border-solid border-2 text-white block px-4 py-2 text-md font-semibold'}
                                                    >
                                                    {c}
                                                    </a>
                                                </Menu.Item>
                                                )   
                                            })}
                                            
                                    </div>
                                </Menu.Items>
                            </Menu>
                            <Menu as="div" className="relative inline-block text-left">
                                <div>
                                    <Menu.Button className="inline-flex w-full justify-center bg-transparent border-gray-600 border-solid border-2 px-4 py-2 text-sm font-medium text-white shadow-sm hover:bg-pink-800">
                                    Precio total
                                    <ChevronDownIcon className="-mr-1 ml-2 h-5 w-5" aria-hidden="true" />
                                    </Menu.Button>
                                </div>
                                <Menu.Items className="absolute right-0 z-10 mt-2 w-56 origin-top-right bg-transparent shadow-lg ring-1 ring-black ring-opacity-5 focus:outline-none">
                                    <div className="py-1">
                                            <Menu.Item>
                                                <a
                                                href="#"
                                                className={'bg-gray-800 border-gray-600 border-solid border-2 text-white block px-4 py-2 text-md font-semibold'}
                                                >
                                                ${total}
                                                </a>
                                            </Menu.Item>
                                    </div>
                                </Menu.Items>
                            </Menu>
                </div>
                <button className="buttonComprar">Comprar</button>  
            </div>
            <Reviews />
            <SeccionEvent seccion={"Te puede interesar"} ruta={"/"} />
            <Footer />
        </div>
    )
}

export default Event;