import { Link } from 'react-router-dom';
import { useSelector, useDispatch } from 'react-redux';
import { useState, useEffect } from 'react';
import { isUserLogged } from '../../utils/validations';
import { checkLocalStorage } from '../../redux/actions';

import '../prePurchase/prePurchase.css'
import { loginUser } from '../../redux/actions';

// import Login from '../../pages/login/login';

const PrePurchase = function () {

    const askLogin = useSelector(state => state.isLogged)
    const dispatch = useDispatch()
    const [input, setInput] = useState({
        email: "",
        password: ""
    })


    useEffect(() => {
        dispatch(checkLocalStorage())
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
                    alert("Error")
                } else {
                    try{
                        // const decode = jwt_decode(loginData.token)
                        // localStorage.setItem("user", JSON.stringify(decode))
                        dispatch(checkLocalStorage())
                        alert("Bienvenido!")
                     
                    } catch(error){
                        console.log(error)
                    }
                }
            })
    }

    return (
        <div className="prepurchase_main">

            <div className='container_forms'>
                {/* if you are already logged in: Get the user info and Display it here */}

                {askLogin ?

                    (<div className='login_ask_container'>
                        <h1>User Info</h1>
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

                <div className='details_container'>

                    <div className='details_subcontainer'>
                        <div className='title_container'>
                            <h4>Detalle de tu pedido</h4>
                        </div>



                        <div className='event_container'>
                            <div>
                                <img src="https://i.ibb.co/NFQGy1h/Put-In.jpg" alt="Put-In" border="0"  className='event_image'/>
                            </div>

                            <div className='event_deatils_container'>
                                <p>Concert Details</p>
                            </div>
                        </div>


                        <div className='subtotal_container'>
                            <div className='subtotal_details'>
                               <div className='subtotal_isolated'>
                                    <h5 className='subtotal_headings'>Cantidad</h5>
                                    <p className='subtotal_description'>1 Entrada</p>
                               </div>

                               <div className='subtotal_isolated'>
                                    <h5 className='subtotal_headings'>Ubicación</h5>
                                    <p className='subtotal_description'>La casa de tu mama</p>
                               </div>

                               <div className='subtotal_isolated'>
                                    <h5 className='subtotal_headings'>Valor unitario</h5>
                                    <p className='subtotal_description'>Gratis!</p>
                               </div>

                               <div className='total_container'>

                               <div className='subtotal_isolated'>
                                    <h5 className='subtotal_headings'>Subtotal</h5>
                                    <p className='subtotal_description'>100</p>
                               </div>

                               <div className='subtotal_isolated'>
                                    <h5 className='subtotal_headings'>Total</h5>
                                    <p className='subtotal_description'>Gratis!</p>
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