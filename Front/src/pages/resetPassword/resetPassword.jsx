import { useDispatch, useSelector } from "react-redux";
import { useEffect, useState } from "react";
import { Link, useNavigate } from "react-router-dom";

import { resetPassword } from "../../redux/actions";



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


    async function submit(e) {
        e.preventDefault()
        dispatch(resetPassword(input))
            .then(val => {
            if(val !== 200){
                console.log(val)
                alert("Error: " + val)
            } else{
                console.log("Success with status: " + val)
                alert("Cambio de contraseña exitoso!")
                navigate("/")
            }
        })
    }
    console.log(input.email)
    console.log(input.password)
    console.log(input.confirmPassword)
    console.log(input.token)

    return(
        <div className="forgotpassword_main">
        <div className="forgotpassword_form_main">

            <div className='forgotpassword_data'>
                <div className="forgotpassword_title">Ingresar nueva contraseña</div>

                <div className='reset_description'>
                    <p>
                        Por tu seguridad la contraseña debe contener al menos una letra mayúscula, 
                        una minúscula, un número, un caracter especial
                    </p>
                </div>

                <form className="forgotpassword_form" onSubmit={submit}>
                    <input 
                    className="forgotpassword_email"
                    type="text"
                    name="password"
                    placeholder="Contraseña nueva"
                    value={input.password}
                    onChange={handleInput}
                    />
                    {formErrors.password && (<p className="warning">{formErrors.password}</p>)}

                    <input 
                    className="forgotpassword_email"
                    type="text"
                    name="confirmPassword"
                    placeholder="Confirmar contraseña"
                    value={input.confirmPassword}
                    onChange={handleInput}
                    />  
                    {formErrors.confirmPassword && (<p className="warning">{formErrors.confirmPassword}</p>) || formErrors.passwordValidation && (<p className="warning">{formErrors.passwordValidation}</p>)}

                    <div className='forgot_buttons'>
                        <button className="reset_button">Restablecer contraseña</button>
                    </div>
                </form>

            </div>
        </div>
    </div>
    )
}

export default ResetPassword;