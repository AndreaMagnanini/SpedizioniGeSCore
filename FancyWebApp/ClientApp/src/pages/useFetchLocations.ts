import {useEffect, useState} from "react";
import { Location } from "../abstractions/Location";

function useFetchLocations(): [Location[], boolean] {
    const [locations, setLocations] = useState<Location[]>([]);
    const [isLoading, setIsLoading] = useState<boolean>(true);
    
    async function fetchUrl() {

        await new Promise(r => setTimeout(r, 5000));
        await fetch("api/location" )
            .then(response => {
                return response.json()
            })
            .then(responseJson => {
                setLocations(responseJson);
            })
            .finally(() => setIsLoading(false));
        setIsLoading(false);
    }

    useEffect(() => {
        fetchUrl();
    }, []);

    return [locations, isLoading];
}

export {useFetchLocations};