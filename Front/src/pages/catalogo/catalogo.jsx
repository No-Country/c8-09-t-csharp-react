import { filterByGenres } from "../../redux/actions";
import { useDispatch, useSelector } from "react-redux"
import { useEffect, useState} from "react"
import SeccionEvent from "../../components/seccionEvents/SeccionEvent";
import "./catalogo.css"
import Carousel from '../../components/Carousel/Carousel'
import axios from "axios"


const Catalogo = () => {

    const [categories, setCategories] = useState([])
    const [nameCategorie, setNameCategorie] = useState("Todos")
    const dispatch = useDispatch()

    const getCategories = async () => {
        const response = await axios.get("https://cohorteapi.azurewebsites.net/api/Categories")
        setCategories(response.data)
    }

    const filterGenres = (e) => {
        dispatch(filterByGenres(e.target.value))
        setNameCategorie(e.target.value)
    }

    useEffect(()=> {
        getCategories()
    }, [])

    return(
        <div className="catalogo-container">
            <Carousel />
            <div className="filtro-container">
                <h3>Filtrar por categoria</h3>
                <form>
                    <select name="filter" onChange={(e)=> {
                        filterGenres(e)
                        }}>
                        <option
                        value="Todos"
                        className="filter-option">Todos</option>
                        {categories?.map((c)=>{
                            return(
                                <option
                                key={c.id}
                                value={c.name}
                                className="filter-option"
                                >{c.name}</option>
                            )   
                        })}
                    </select>
                </form>
            </div>
            <SeccionEvent seccion={nameCategorie} ruta={"/catalogo"}/>
        </div>
    )
}

export default Catalogo;
