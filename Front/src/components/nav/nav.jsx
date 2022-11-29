import "./Nav.css"
import {Link} from "react-router-dom"
import { useDispatch, useSelector } from "react-redux"
import { useEffect, useState} from "react"
import { checkLocalStorage } from "../../redux/actions"
import { clearLocalStorage } from "../../utils/localStorage"

//Tailwind components
import { Menu } from '@headlessui/react'
import { ChevronDownIcon } from '@heroicons/react/20/solid'

const Nav = () => {     
    
    const [userName, setUserName] = useState("Nadir Blanco")
    const dispatch = useDispatch()
    const isLogged = useSelector(state => state.isLogged)

    const items = [
        {
            name: "Mis entradas",
            action: function(){
                console.log("Mis entradas")
            }
        },
        {
            name: "Mi cuenta",
            action: function(){
                console.log("Mis cuenta")
            }
        },
        {
            name: "Mi historial",
            action: function(){
                console.log("Mis historial")
            }
        },
        {
            name: "Mi suscripcion",
            action: function(){
                console.log("Mis suscripcion")
            }
        },
        {
            name: "Cerrar sesion",
            action: function(){
                clearLocalStorage("user")
                dispatch(checkLocalStorage())
            }
        },
    ]

    useEffect(()=> {
        dispatch(checkLocalStorage())
    }, [])

    return(
        <nav>
            <div className="logo-links">
                <Link to={"/"} className="logo">
                    <img src="/logo-ticketfan.svg" alt="logo"/>
                </Link>
                <ul>
                    <li className="active"><Link to={"/"} >Inicio</Link></li>
                    <li><Link to={"/"}>Categorias</Link></li>
                    <li><Link to={"/"}>Contacto</Link></li>
                </ul>
            </div>
            <div className="button-carrito">
                {isLogged ? 
                <Menu as="div" className="relative inline-block text-left">
                    <div>
                        <Menu.Button className="inline-flex w-full justify-center rounded-md border border-gray-300 bg-white px-4 py-2 text-sm font-medium text-gray-700 shadow-sm hover:bg-gray-50 focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:ring-offset-2 focus:ring-offset-gray-100">
                        {userName}
                        <ChevronDownIcon className="-mr-1 ml-2 h-5 w-5" aria-hidden="true" />
                        </Menu.Button>
                    </div>
                    <Menu.Items className="absolute right-0 z-10 mt-2 w-56 origin-top-right rounded-md bg-white shadow-lg ring-1 ring-black ring-opacity-5 focus:outline-none">
                        <div className="py-1">
                            {items.map((i)=>{
                                return(
                                <Menu.Item onClick={()=>{
                                    i.action()
                                }}>
                                    <a
                                    href="#"
                                    className={'bg-gray-100 text-gray-900 block px-4 py-2 text-sm'}
                                    >
                                    {i.name}
                                    </a>
                                </Menu.Item>
                                )
                            })}
                        </div>
                    </Menu.Items>
                </Menu>
                :
                <Link to={"/login"}>
                    <div className="buttonIngresar">
                        <img src="/perfil.svg" alt="perfil" />
                        <span>Ingresar</span>
                    </div>
                </Link>
                }
                <Link to={"/"}><img src="/carrito.svg" alt="carrito"/></Link> 
            </div>
        </nav>
    )
}

export default Nav;
