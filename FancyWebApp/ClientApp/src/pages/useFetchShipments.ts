import { Shipment } from './../abstractions/Shipment';
import {useEffect, useState} from "react";

function useFetchShipments(year): [Shipment[], boolean]{
    const [shipments, setShipments] = useState<Shipment[]>([]);
    const [isLoading, setIsLoading] = useState<boolean>(true);

    async function fetchUrl(year) {

        await new Promise(r => setTimeout(r, 5000));
        await fetch("api/shipment/" + year)
            .then(response => {
                return response.json()
            })
            .then(responseJson => {
                setShipments(responseJson);
            })
            .finally(() => setIsLoading(false));
        setIsLoading(false);
    }

    useEffect(() => {
        fetchUrl(year);
    }, [year]);

    return [shipments, isLoading];
}

export {useFetchShipments}