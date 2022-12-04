import { Alert } from "../../utils/alert";
import rejectionImg from '../../../src/rejection.svg'
import responseImg from '../../../src/response.svg'
import '../forgotPassword/forgotPassword.css'
import { Link, useNavigate } from 'react-router-dom';
import { useState, useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { forgotPassword } from '../../redux/actions';

const ForgotPassword = function () {
    // Funcion que va a checar si el correo existe 
    const dispatch = useDispatch()
    const forgotPassData = useSelector(state => state.forgotPasswordToken)
    const [email, setEmail] = useState("")

    function handleInput(e){
        setEmail(e.target.value)
    }

    function submit(e){
        e.preventDefault()
        dispatch(forgotPassword(email))
        .then(val => {
            if (val !== 200) {
                
                // alert("Error, favor de verificar el correo")
                Alert.fire({
                    title: 'Ooops',
                    html: `No hay ninguna cuenta de usuario asignada al correo: </br> <b>${email}</b>`,
                    imageUrl: rejectionImg,
                    imageAlt: 'error',
                    confirmButtonText: `<button class="botonPrincipal" > OK </button>`,
                })
            } else {
                try{
                    // alert("Verificacion exitosa!")
                    Alert.fire({
                        title: '¡Listo! Revisar tu correo',
                        html: `Las instrucciones fueron enviadas a: </br> <b>${email}</b>`,
                        imageUrl: responseImg,
                        imageAlt: 'confirm',
                        confirmButtonText: `<button class="botonPrincipal" > OK </button>`,
                    })
                } catch(error){
                    console.log(error)
                }
            }
        })
    }

    console.log(forgotPassData)
    // 
    return (
        <div className="forgotpassword_main">
            <div className="forgotpassword_form_main">

                <div className='forgotpassword_data'>
                    <div className="forgotpassword_title">Recuperar Contraseña</div>

                    <div className='reset_description'>
                        <p>
                            Si olvidaste la contraseña de acceso a tu cuenta, por favor,
                            introduce el email con el que te registraste y te enviaremos
                            las instrucciones para recuperar tu contraseña:
                        </p>
                    </div>

                    <form className="forgotpassword_form" onSubmit={submit}>
                        <input 
                        className="forgotpassword_email"
                        type="text"
                        name="email"
                        placeholder="Email"
                        value={email}
                        onChange={handleInput}
                        />

                        <div className='forgot_buttons'>
                            <Link className='cancel_button' to="/login">Cancelar</Link>
                            {/* <button className='cancel_button'>Cancelar</button> */}
                            <button className="reset_button">Recuperar mi contraseña</button>
                        </div>
                    </form>

                </div>
            </div>
        </div>
    )
}

export default ForgotPassword
