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
    
    const userInfo = useSelector(state => state.userloginData)
    const userStorage = useSelector(state => state.singleUser)
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

    useEffect(()=> {
        setUserName(userInfo["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"])
    }, [userInfo])


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
                        <Menu.Button className="inline-flex w-full justify-center rounded-2xl bg-pink-500 px-4 py-2 text-sm font-medium text-white shadow-sm hover:bg-pink-600">
                        {userInfo.length === 0 ? userStorage["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"]:
                        userName
                        }
                        <ChevronDownIcon className="-mr-1 ml-2 h-5 w-5" aria-hidden="true" />
                        </Menu.Button>
                    </div>
                    <Menu.Items className="absolute right-0 z-10 mt-2 w-56 origin-top-right rounded-md bg-white shadow-lg ring-1 ring-black ring-opacity-5 focus:outline-none">
                        <div className="py-1">
                            {items.map((i, index)=>{
                                return(
                                <Menu.Item key={index} onClick={()=>{
                                    i.action()
                                }}>
                                    <a
                                    href="#"
                                    className={'bg-gray-100 text-gray-900 block px-4 py-2 text-md font-semibold'}
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
                <Link to={"/"} className="carrito"><img src="/carrito.svg" alt="carrito"/></Link> 
            </div>
        </nav>
    )
}

export default Nav;
