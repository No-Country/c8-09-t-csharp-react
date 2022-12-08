import { Link, useNavigate } from 'react-router-dom';
import { useSelector, useDispatch } from 'react-redux';
import { useState, useEffect } from 'react';
import { isUserLogged } from '../../utils/validations';
import { checkLocalStorage } from '../../redux/actions';
import moment from 'moment';
import '../prePurchase/prePurchase.css'
import { loginUser, eventDetails } from '../../redux/actions';
import CheckoutForm from '../CheckoutForm/checkoutForm';
import { Alert } from "../../utils/alert";
import rejectionImg from '../../../src/rejection.svg'
import responseImg from '../../../src/response.svg'

// import Login from '../../pages/login/login';

const PrePurchase = function () {

    let eventJSON = localStorage.getItem("prePurchase")
    let eventInfo = JSON.parse(eventJSON)

    const askLogin = useSelector(state => state.isLogged)
    const event = useSelector(state => state.singleEventDetail)
    const dispatch = useDispatch()
    const navigate = useNavigate()
    const [input, setInput] = useState({
        email: "",
        password: ""
    })


    useEffect(() => {
        dispatch(checkLocalStorage())

        if(eventInfo){
            dispatch(eventDetails(eventInfo.eventId))
        } else{
            return
        }
    }, [])


    function handleInput(e) {
        setInput({
            ...input,
            [e.target.name]: e.target.value
        })
    }

    
    function submit(e) {
        e.preventDefault()
        dispatch(loginUser(input))
            .then(val => {
                if (val !== 200) {
                    // alert(`Error ${val.response.status}: ${val.response.statusText}`)
                    Alert.fire({
                        title: 'Ooops',
                        html: `Por favor verifica los datos: </br> <b>${input.email}</b>`,
                        imageUrl: rejectionImg,
                        imageAlt: 'error',
                        confirmButtonText: `<button class="botonPrincipal" >OK</button>`,
                    })
                } else {
                    try{
                        // const decode = jwt_decode(loginData.token)
                        // localStorage.setItem("user", JSON.stringify(decode))
                        dispatch(checkLocalStorage())
                        Alert.fire({
                            title: 'Bienvenido!',
                            html: `Ingresaste con el correo: </br> <b>${input.email}</b>`,
                            imageUrl: responseImg,
                            imageAlt: 'confirm',
                            confirmButtonText: `<button class="botonPrincipal" >OK</button>`,
                        })
                     
                    } catch(error){
                        return (error)
                    }
                }
            })
    }

    function onclick(){
        navigate("/checkout")
    }

    return (
        <div className="prepurchase_main">

            <div className='container_forms'>
                {/* if you are already logged in: Get the user info and Display it here */}

                {askLogin ?

                    (<div className='login_ask_container'>
                        <CheckoutForm />
                    </div>)

                    :

                    (<div className="prepurchase_form_main">
                        <div className='prepurchase_form_subcontainer'>
                            <h5 className='prepurchase_login_title'>Antes de continuar, por favor identifícate</h5>

                            <div className='login_ask_form_container'>
                                <form className='form' onSubmit={submit}>
                                    <input
                                        className='prepurchase_form_input'
                                        type="text"
                                        name="email"
                                        placeholder="Email"
                                        value={input.email}
                                        onChange={handleInput}
                                    />

                                    <input
                                        className='prepurchase_form_input'
                                        type="text"
                                        name="password"
                                        placeholder="Contraseña"
                                        value={input.password}
                                        onChange={handleInput}
                                    />

                                    <div className='prepurchase_forgot_password'><Link to="/forgotPassword">¿Olvidaste tu contraseña?</Link></div>

                                    <button className='prepurchase_login_button'>Iniciar Sesión</button>
                                </form>

                                <p className='prepurchase_letter'>O</p>

                                <br />


                                <button className="prepurchase_google_button">
                                    <img className="google_icon" src="../../../G_Logo_Clean.png" alt="Google Icon" height={"24px"} width={"24px"} />
                                    Ingresar con Google
                                </button>




                                <div className='prepurchase_no_account'>¿No tienes una cuenta? 
                                <Link className="prepurchase_register_link" to="/register">Regístrate</Link></div>
                            </div>
                        </div>

                    </div>
                    )}

                {/* /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //////////////////////////////////////////////// PRE PURCHASE DETAILS START HERE  //////////////////////////////////////////////// */}
                
                <div className='details_container'>

                    <div className='details_subcontainer'>
                        <div className='title_container'>
                            <h4>Detalle de tu pedido</h4>
                            {/* <div>
                            <button className='purchase_button' onClick={onclick}>Proceder al pago</button>
                            </div> */}
                        </div>



                        <div className='event_container'>
                            <div>
                                <img src={event.frontPageImage} alt="Put-In" border="0"  className='event_image' onError={(e)=>{e.target.onerror = null; e.target.src="https://www.dafont.com/forum/attach/orig/9/9/997801.gif"}}/>
                            </div>

                            <div className='event_data_container'>
                            <div className='event_title_container'>
                                <p>{event.eventName}</p>
                            </div>

                            <div className='event_venue_container'>
                                <img src='../../src/ubicacion.png'/>
                                <p className='event_icon'>{event.venue}</p>
                            </div>

                            <div className='event_venue_container'>
                                 <img src='../../src/calendario.png'/>
                                    <p className='event_icon'>{moment(event.eventTime).format('D MMM, YYYY')}</p>
                            </div> 

                             <div className='event_venue_container'>
                                 <img src='../../src/schedule.png'/>
                                    <p className='event_icon'>{moment(event.eventTime).format('h:mm a')}</p>
                            </div>

                              <div className='event_venue_container'>
                                 <img src='../../src/money.png'/>
                                <p className='event_icon'>$ {eventInfo.price} C/U</p>
                            </div>

                            </div>
                        </div>

                        


                        <div className='subtotal_container'>
                            <div className='subtotal_details'>
                               <div className='subtotal_isolated'>
                                    <h5 className='subtotal_headings'>Cantidad</h5>
                                    <p className='subtotal_description'>{eventInfo.quantity}</p>
                               </div>

                               <div className='subtotal_isolated'>
                                    <h5 className='subtotal_headings'>Ubicación</h5>
                                    <p className='subtotal_description'>{eventInfo.section}</p>
                               </div>

                               <div className='subtotal_isolated'>
                                    <h5 className='subtotal_headings'>Valor unitario</h5>
                                    <p className='subtotal_description'>$ {eventInfo.price}</p>
                               </div>

                               <div className='total_container'>

                               <div className='subtotal_isolated'>
                                    <h5 className='subtotal_headings'>Subtotal</h5>
                                    <p className='subtotal_description'>$ {eventInfo.eventTotal}</p>
                               </div>

                               <div className='subtotal_isolated'>
                                    <h5 className='subtotal_headings'>Total</h5>
                                    <p className='subtotal_description'>$ {eventInfo.eventTotal}</p>
                               </div>

                               </div>
                            </div>
                        </div>
                    </div>

                </div>


            </div>

        </div>
    )
}

export default PrePurchase;