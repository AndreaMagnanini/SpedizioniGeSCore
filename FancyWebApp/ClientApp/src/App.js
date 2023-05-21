import React from 'react';
import { Route, Routes} from 'react-router-dom';
import AppRoutes from './AppRoutes';

export default function App () {
    return (
            <Routes>
                {AppRoutes.map(route => (
                    <Route key={route.index} path={route.path} element={route.element}/>
                ))}
            </Routes>
    )
}
