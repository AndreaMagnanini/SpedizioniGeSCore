import {useEffect, useState} from "react";
import { Airport } from "../abstractions/Airport";

function useFetchAirports(): [Airport[], boolean] {
    const [airports, setAirports] = useState<Airport[]>([]);
    const [isLoading, setIsLoading] = useState<boolean>(true);
    async function fetchUrl() {

        await new Promise(r => setTimeout(r, 5000));
        await fetch("api/airport")
            .then(response => {
                return response.json()
            })
            .then(responseJson => {
                setAirports(responseJson);
            })
            .finally(() => setIsLoading(false));
        setIsLoading(false);
    }

    useEffect(() => {
        fetchUrl();
    }, []);

    return [airports, isLoading];
}

export {useFetchAirports}