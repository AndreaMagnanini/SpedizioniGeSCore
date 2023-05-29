import React from 'react';
import {BrowserRouter, Route, Routes} from 'react-router-dom';
import AppRoutes from './AppRoutes';
import FerrariHeader from "./components/FerrariHeader";
const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');

export default function App () {
    return (
        <BrowserRouter basename={baseUrl}>
            <FerrariHeader>
                <Routes>
                    {AppRoutes.map(route => (
                        <Route key={route.index} path={route.path} element={route.element}/>
                    ))}
                </Routes>
            </FerrariHeader>
        </BrowserRouter>
    )
}
