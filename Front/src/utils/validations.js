export const isUserLogged = () => {
    return localStorage.getItem('user') ? true : false
}

export const isUserAdmin = () => {

    const user = JSON.parse(localStorage.getItem('user'))

    return user?.rol === "admin"

}