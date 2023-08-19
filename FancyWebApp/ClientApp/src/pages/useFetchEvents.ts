import {useEffect, useState} from "react";
import { Event } from "../abstractions/Event";

function useFetchEvents(year): [Event[], boolean] {
    const [events, setEvents] = useState<Event[]>([]);
    const [isLoading, setIsLoading] = useState<boolean>(true);

    async function fetchUrl(year: number) {

        await new Promise(r => setTimeout(r, 5000));
        await fetch(`api/event/${year}`)
            .then(response => {
                return response.json()
            })
            .then(responseJson => {
                setEvents(responseJson);
            })
            .finally(() => setIsLoading(false));
        setIsLoading(false);
    }

    useEffect(() => {
        fetchUrl(year);
    }, [year]);

    return [events, isLoading];
}

export {useFetchEvents}