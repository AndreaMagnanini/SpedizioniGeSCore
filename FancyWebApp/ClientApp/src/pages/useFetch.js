import {useEffect, useState} from "react";

function useFetch(year) {
    const [shipments, setShipments] = useState([]);
    const [isLoading, setIsLoading] = useState(true);
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

export {useFetch}