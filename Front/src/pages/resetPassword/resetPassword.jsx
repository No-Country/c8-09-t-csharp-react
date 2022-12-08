import './resetPassword.css'
import { Alert } from "../../utils/alert";
import rejectionImg from '../../../src/rejection.svg'
import responseImg from '../../../src/response.svg'
import { useDispatch, useSelector } from "react-redux";
import { useEffect, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { checkLocalStorage } from "../../redux/actions";
import { resetPassword, loginUser } from "../../redux/actions";



function formValidations(input){

    var passwordCheck = new RegExp("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})")

    let formErrors = {}

    if (!input.password) {
        formErrors.password = "Por favor escriba su nueva contraseña"
    }
    if (!input.confirmPassword) {
        formErrors.confirmPassword = "Por favor confirme su contraseña"
    }
    if (!passwordCheck.test(input.password)) {
        formErrors.password = "Incluya mayuscula, minuscula, numero, simbolo, y más de 8 caracteres"
    }
    if (input.password !== input.confirmPassword) {
        formErrors.passwordValidation = "Contraseñas deben de ser iguales"
    }

    return formErrors;
}

const ResetPassword = function(){

    let token = localStorage.getItem("forgotPasswordToken")
    let data = JSON.parse(token)

    let dataToken = data.token
    let dataEmail = data.email

    const navigate = useNavigate()
    const dispatch = useDispatch()
    const [formErrors, setFormErrors] = useState({})
    const [input, setInput] = useState({
        email: dataEmail,
        password: "",
        confirmPassword: "",
        token: dataToken
    })

 

    function handleInput(e) {
        setInput({
            ...input,
            [e.target.name]: e.target.value,
        })
        setFormErrors(formValidations({
            ...input,
            [e.target.name]: e.target.value
        }))
    }


     function submit(e) {
        e.preventDefault()
        dispatch(resetPassword(input))
            .then(val => {
            if(val !== 200){
                // console.log(val)
                
                Alert.fire({
                    title: 'Ooops',
                    html: `Hubo un error, intenta de nuevo`,
                    imageUrl: rejectionImg,
                    imageAlt: 'error',
                    confirmButtonText: `<button class="botonPrincipal" >OK</button>`,
                })
            } else{
                // console.log("Success with status: " + val)
                Alert.fire({
                    title: '¡Tu contraseña ha sido actualizada!',
                    html: `Bienvenido </br> <b>${input.email}</b>`,
                    imageUrl: responseImg,
                    imageAlt: 'confirm',
                    confirmButtonText: `<button class="botonPrincipal" >OK</button>`,
                })
                localStorage.removeItem('forgotPasswordToken')
                dispatch(loginUser({email: input.email, password: input.password}))
                    .then(val => {
                        dispatch(checkLocalStorage())
                        navigate("/")
                    })
            }
        })

    }
    // console.log(input.email)
    // console.log(input.password)
    // console.log(input.confirmPassword)
    // console.log(input.token)

    return(
        <div className="resetpassword_main">
        <div className="resetpassword_form_main">

            <div className='resetpassword_data'>
                <div className="resetpassword_title">Ingresar nueva contraseña</div>

                <div className='resetpassword_description'>
                    <p>
                        Por tu seguridad la contraseña debe contener al menos una letra mayúscula, 
                        una minúscula, un número, y un caracter especial
                    </p>
                </div>

                <form className="resetpassword_form" onSubmit={submit}>
                    <div className="resetpassword_form_inputContainer">
                    <div>{formErrors.password && (<p className="forgotpassword_warning">{formErrors.password}</p>)}</div>
                    <input 
                    className="resetpassword_email"
                    type="text"
                    name="password"
                    placeholder="Contraseña nueva"
                    value={input.password}
                    onChange={handleInput}
                    />
                    

                    <div>{formErrors.confirmPassword && (<p className="forgotpassword_warning">{formErrors.confirmPassword}</p>) || formErrors.passwordValidation && (<p className="forgotpassword_warning">{formErrors.passwordValidation}</p>)}</div>     
                    <input 
                    className="resetpassword_email"
                    type="text"
                    name="confirmPassword"
                    placeholder="Confirmar contraseña"
                    value={input.confirmPassword}
                    onChange={handleInput}
                    />  
                
                    </div>

                    <div className='reset_buttons'>
                        <button className="passwordreset_button">Restablecer contraseña</button>
                    </div>
                </form>

            </div>
        </div>
    </div>
    )
}

export default ResetPassword;