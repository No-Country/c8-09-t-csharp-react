import "./topVendidos.css"

const TopVendidos = () => {

    return(
        <div className="vendidosContainer">
                <h1>Top mas vendidos</h1>
                <div className="topVendidos">
                    <div className="img" style={{backgroundImage: `url(/imagen-larga.png)`}}>
                        <div className="info">
                            <h1>Festival de todo lo que nos hace bien</h1>
                            <h2>Hipodromo de palermo</h2>
                            <button className="buttonInfo">Mas informacion</button>
                        </div>
                    </div>
                    <div className="img" style={{backgroundImage: `url(/imagen-larga.png)`}}>
                            <div className="info">
                                <h1>Festival de todo lo que nos hace bien</h1>
                                <h2>Hipodromo de palermo</h2>
                                <button className="buttonInfo">Mas informacion</button>
                            </div>
                    </div>
                    <div className="img" style={{backgroundImage: `url(/imagen-larga.png)`}}>
                            <div className="info">
                                <h1>Festival de todo lo que nos hace bien</h1>
                                <h2>Hipodromo de palermo</h2>
                                <button className="buttonInfo">Mas informacion</button>
                            </div>
                    </div>
                </div>
        </div>
    )
}

export default TopVendidos