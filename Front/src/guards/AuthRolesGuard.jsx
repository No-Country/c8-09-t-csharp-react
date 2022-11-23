import { Navigate, Outlet, useLocation } from 'react-router-dom'

export const AuthRolesGuard = ({ isAllowed }) => {
	const location = useLocation()
	return isAllowed ? (
		<Outlet />
	) : (
		<Navigate to={'/account'} state={{ from: location }} replace />
	)
}
