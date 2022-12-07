import { Link } from "react-router-dom";
import "../error/Error.css"



const Error = () => {
  return (
    <div className="error_main">
        <div className="vectors">
    <span><img src="/vector.svg" className="vector1" alt="vector" /></span>
    <span><img src="/vector.svg" className="vector2" alt="vector" /></span>
    <span><img src="/vector.svg" className="vector3" alt="vector" /></span>
        </div>

        <div className="cards_group">
        
            <div className="error_card1">
                <img className="card_logo" src="/logo-ticketfan.svg" alt="logo" />
                <div className="text_card1">
                <h1 className="tittle_card1">ERROR 404</h1>
                <h2 className="subtittle_card1">PAGINA NO ENCONTRADA</h2>
                
                <button className="button_card1" ><Link to="/">Volver al inicio</Link></button>
                </div>
            </div>

            <div className="error_card2">
            <h1 className="tittle_card2">OOPS!</h1>
            <h2 className="subtittle_card2">ALGO NO SALIÓ BIEN</h2>
            <img className="card_barcode" src="/barcode.png" alt="barcode" />
            </div>
        </div>
    
        
    </div>
  )
}

export default Error;
