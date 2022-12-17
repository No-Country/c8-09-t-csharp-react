import { useState } from "react"

const Dropdown = function() {
    
    const [input, setInput] = useState({
        Platea_izquierda: "",
        Platea_central: "",
        // Platea_derecha: "",
        // Palco_izquierdo: "",
        // Palco_derecho: "",
        quantity: 1
    })

    function handleInput(e){
        setInput({
            ...input,
            [e.target.name]: e.target.value
        })
    }

    function handleQuantity(e){
        setInput({
            ...input,
            quantity: e.target.value
        })
    }

    function count(){
        let amount = []
        for(let i = 1; i < 11; i++){
            amount.push(
                <option key={i} value={i} name="quantity">{i}</option>
            )
        }
        return amount
    }

    console.log(input)
    // console.log(input.quantity)
    return(
        <div>
            <form>
            {/* <label for="price">Ubicacion: </label> */}
            <select onChange={e => handleInput(e)}>
                {/* <option>Ubicacion</option> */}
                <option value={input.Platea_izquierda} name="Platea_izquierda">Platea izquierda</option>
                <option value={input.Platea_central} name="Platea_central">Platea central</option>
                {/* <option value={input.Platea_derecha} name="Platea_derecha">Platea derecha</option>
                <option value={input.Palco_izquierdo} name="Palco_izquierdo">Palco izquierdo</option>
                <option value={input.Palco_derecho} name="Palco_derecho">Palco derecho</option> */}
            </select>

            <select onChange={e => handleQuantity(e)}>
                {/* <option>Precio</option> */}
                {count()}
            </select>

            <div>Total</div>
        </form>
        </div>
    )
}

export default Dropdown;