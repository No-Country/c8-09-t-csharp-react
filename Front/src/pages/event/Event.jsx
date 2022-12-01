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

const Event = () => {

    const [event, setEvent] = useState({})
    const { id } = useParams()

    const items = [
        {
            name: "Precio"
        },
        {
            name: "Ubicacion"
        },
        {
            name: "Cantidad"
        },
        {
            name: "Precio total"
        }
    ]

    const getEvent = async () => {
        const response = await axios.get(`https://cohorteapi.azurewebsites.net/api/Events/${id}`)
        setEvent(response.data)
    }   

    useEffect(()=>{
        getEvent()
        console.log(event)
    }, [])

    return(
        <div>
            {/* <h3>{id}</h3>
            <h4>aidaidniaefref</h4> */}
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
                    {items.map((item)=>{
                        return(
                            <Menu as="div" className="relative inline-block text-left">
                                <div>
                                    <Menu.Button className="inline-flex w-full justify-center bg-pink-500 px-4 py-2 text-sm font-medium text-white shadow-sm hover:bg-pink-600">
                                    {item.name}
                                    <ChevronDownIcon className="-mr-1 ml-2 h-5 w-5" aria-hidden="true" />
                                    </Menu.Button>
                                </div>
                                <Menu.Items className="absolute right-0 z-10 mt-2 w-56 origin-top-right rounded-md bg-white shadow-lg ring-1 ring-black ring-opacity-5 focus:outline-none">
                                    <div className="py-1">
                                            <Menu.Item>
                                                <a
                                                href="#"
                                                className={'bg-gray-100 text-gray-900 block px-4 py-2 text-md font-semibold'}
                                                >
                                                Item
                                                </a>
                                            </Menu.Item>
                                            <Menu.Item>
                                                <a
                                                href="#"
                                                className={'bg-gray-100 text-gray-900 block px-4 py-2 text-md font-semibold'}
                                                >
                                                Item
                                                </a>
                                            </Menu.Item>
                                            <Menu.Item>
                                                <a
                                                href="#"
                                                className={'bg-gray-100 text-gray-900 block px-4 py-2 text-md font-semibold'}
                                                >
                                                Item
                                                </a>
                                            </Menu.Item>
                                    </div>
                                </Menu.Items>
                            </Menu>
                        )
                    })}
                </div>
                <button className="buttonComprar">Comprar</button>  
            </div>
            <SeccionEvent seccion={"Te puede interesar"} ruta={"/"} />
            <Footer />
        </div>
    )
}

export default Event;