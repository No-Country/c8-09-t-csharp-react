import './checkoutForm.css'
import { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { useDispatch, useSelector } from 'react-redux';
import { purchaseEvent } from '../../redux/actions';
import { Alert } from "../../utils/alert";

import rejectionImg from '../../../src/rejection.svg'
import responseImg from '../../../src/response.svg'


const CheckoutForm = function(){

    let userJSON = localStorage.getItem("user")
    let userInfo = JSON.parse(userJSON)

    let eventJSON = localStorage.getItem("prePurchase")
    let eventInfo = JSON.parse(eventJSON)

    const dispatch = useDispatch()
    const navigate = useNavigate()
    const purchase = useSelector(state => state.purchaseEventResponse)
    const [buttonState, setButtonState] = useState(true)
    const [input, setInput] = useState({
        CardName: "",
        CardNumber: "",
        CardMonth: "",
        CardYear: "",
        CVV: "",
        UserEmail: userInfo["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"],
        eventId: eventInfo.eventId,
        qty: eventInfo.quantity,
        section: eventInfo.section,
        price: eventInfo.eventTotal
    })

    function handleInput(e){
        setInput({
            ...input,
            [e.target.name]: e.target.value
        })
    }

    useEffect(() => {
        if (!input.CardName || 
            input.CardName === "" || 
            input.CardNumber === "" || input.CardNumber.length !== 16 ||
            input.CardMonth === "" || input.CardMonth.length !== 2 ||
            input.CardYear === "" || input.CardYear.length !== 2 ||
            input.CVV === "" || input.CVV.length !== 3) {
            setButtonState(true)
        } else {
            setButtonState(false)
        }
    }, [input])

    function cancelPurchase(){
        setInput({
            CardName: "",
            CardNumber: "",
            CardMonth: "",
            CardYear: "",
            CVV: "",
            UserEmail: "",
            eventId: 0,
            qty: 0,
            section: "",
            price: 0
        })
        navigate("/")
    }

    function submit(e){
        e.preventDefault()
        dispatch(purchaseEvent(input))
            .then(val => {
                if (val !== 200) {
                    Alert.fire({
                        title: 'Ooops',
                        html: `Por favor verifica los datos de tu tarjeta: </br>`,
                        imageUrl: rejectionImg,
                        imageAlt: 'error',
                        confirmButtonText: `<button class="botonPrincipal" >OK</button>`,
                    })
                    
                } else {
                    try{
                        Alert.fire({
                            title: 'Gracias por tu compra',
                            html: `<h4>Numero de Orden: </h4> </br> <h5><b>${purchase.id}</b></h5>`,
                            imageUrl: responseImg,
                            imageAlt: 'confirm',
                            confirmButtonText: `<button class="botonPrincipal" >Regresar al inicio</button>`,
                        })
                        // console.log(purchase)
                        localStorage.removeItem("prepurchase")
                     
                    } catch(error){
                        // console.log(error)
                    }
                }
            })
            // cancelPurchase()
    }

    // console.log(input)

    return(
        <div className="checkoutForm_main_container">
            <div className="checkoutFrom_subContainer">
                <div className='checkoutForm_title_container'><h5 className='checkoutForm_title'>Ingresa los datos de tu tarjeta</h5></div>

                <div className="form_inputs_container">
                    <form onSubmit={submit}>
                        <div className='checkoutForm_cardName_container'>
                        <input 
                        type="text" 
                        placeholder="Titular de la tarjeta" 
                        className='checkoutForm_input'
                        name='CardName'
                        value={input.CardName}
                        onChange={handleInput}
                        />
                        </div>

                        <div className='checkoutForm_card_container'>
                            <input 
                            type="text"
                            placeholder="Numero de tarjeta" 
                            maxLength="16"
                            className='checkoutForm_input_card'
                            name='CardNumber'
                            value={input.CardNumber}
                            onChange={handleInput}
                            /> 

                            <div className='checkoutForm_hyphen'>-</div>
                            <div type="text" className='checkoutForm_input_cardLogo'><img src='../../src/Logos.png'/></div>
                        </div>

                        <div className='checkoutForm_fecha_container'>
                            <div><p>Fecha de Vencimiento</p></div>
                            
                            <div className='checkoutForm_fecha_subcontainer'>
                                <input 
                                type="text" 
                                placeholder="MM" 
                                maxLength="2"
                                className='checkoutForm_input_fecha'
                                name='CardMonth'
                                value={input.CardMonth}
                                onChange={handleInput}
                                />

                                <div className='checkoutForm_hyphen'>-</div>
                                <input 
                                type="text" 
                                placeholder="AA" 
                                maxLength="2"
                                className='checkoutForm_input_fecha'
                                name='CardYear'
                                value={input.CardYear}
                                onChange={handleInput}
                                />
                            </div>

                        </div>

                        <div className='checkoutForm_CVV_container'>
                            <div className='checkoutForm_CVV_Title'><p>Codigo de Seguridad</p></div>
                            <div>
                                <input 
                                type="text" 
                                placeholder="CVC" 
                                maxLength="3"
                                className='checkoutForm_input_CVV'
                                name='CVV'
                                value={input.CVV}
                                onChange={handleInput}
                                />
                            </div>
                        </div>

                        <div className='checkoutForm_buttons_container'>
                            <button className='checkoutForm_button_cancel' onClick={cancelPurchase}>Cancelar Compra</button>
                            <button className='checkoutForm_button_finish' disabled={buttonState}>Realizar Pago</button>
                        </div>
                    </form>
                </div>
            </div>

        </div>
    )
}

export default CheckoutForm;