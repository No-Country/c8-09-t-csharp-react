import "../login/login.css"
import { Link } from "react-router-dom";

///////// ESTO ES PARA EL LOGIN DE GOOGLE /////////////
// import GoogleLogin from 'react-google-login';
// import { gapi } from "gapi-script";
// const idClientGoogleLogin = ""
//////////////////////////////////////////////////////


const Login = function () {
    return (
        <div className="login_main">
        {/* <div className="w-full h-screen bg-cover bg-[url('../../../public/Login_Background.jpeg')]"> */}
          
            {/* <div className="flex flex-col items-center bg-transparent" >
            Ingresar a Cuenta
         
            <button>Google Login Component</button>
            <form>
                <input placeholder="Email"/>
                <br />
                <input placeholder="Contraseña"/>
               
                <a href="#">¿Olvidaste tu contraseña? </a>
               
                <button>Iniciar Sesión</button>
            </form>

            ¿No tienes una cuenta? <a href="#">Regístrate</a> 
           </div>
        </div> */}

            <div className="login_form_main">
                <div className="login_title">Ingresar a tu Cuenta</div>
                
                {/* <input className="google_button" type="image" src="../../../G_Icon.png" width={"24px"} height={"24px"} float={"right"} /> */}
        
                <button className="google_button">
                   <img className="google_icon" src="../../../G_Logo_Clean.png" alt="Google Icon" height={"24px"} width={"24px"}/>
                    Continuar con Google
                </button>
                
                <br />
                O 
                <form className="login_form">
                    <input className="form_button" type="text" placeholder="Email" />
                    
                    <input className="form_button" type="password" placeholder="Contraseña" />
                    
                    <div className="forgot_password"><Link to="/forgotPassword">¿Olvidaste tu contraseña?</Link></div>
                    
                    <button className="login_button">Iniciar Sesión</button>
                </form>

                <div>¿No tienes una cuenta? <Link className="register_link" to="/register">Regístrate</Link></div>
            </div>
        </div>

        //     LOGIN
        // </div>
    )
}

export default Login;