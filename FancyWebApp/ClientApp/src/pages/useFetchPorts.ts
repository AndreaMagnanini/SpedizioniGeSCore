import {useEffect, useState} from "react";
import { Port } from "../abstractions/Port";

function useFetchPorts(): [Port[], boolean] {
    const [ports, setPorts] = useState<Port[]>([]);
    const [isLoading, setIsLoading] = useState<boolean>(true);
    
    async function fetchUrl() {

        await new Promise(r => setTimeout(r, 5000));
        await fetch("api/port")
            .then(response => {
                return response.json()
            })
            .then(responseJson => {
                setPorts(responseJson);
            })
            .finally(() => setIsLoading(false));
        setIsLoading(false);
    }

    useEffect(() => {
        fetchUrl();
    }, []);

    return [ports, isLoading];
}

export {useFetchPorts}