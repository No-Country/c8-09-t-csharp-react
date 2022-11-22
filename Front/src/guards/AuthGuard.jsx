import { Navigate, Outlet } from 'react-router-dom'

export const AuthGuard = ({ redirectPath = '/login', isAllowed }) => {
	return !isAllowed ? <Navigate to={redirectPath} replace /> : <Outlet />
}
