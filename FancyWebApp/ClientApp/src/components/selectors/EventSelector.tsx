import React from 'react'
import Autocomplete from '@mui/material/Autocomplete';
import { styled } from '@mui/material';
import { Event } from '../../abstractions/Event';
import { TextField } from '@material-ui/core';

const StyledBigAutocomplete = styled(Autocomplete)({
    "& .MuiInputLabel-outlined:not(.MuiInputLabel-shrink)": {
        transform: "translate(100px, 20px) scale(1);"
    },
    "& .MuiAutocomplete-inputRoot": {
        '&[class*="MuiOutlinedInput-root"] .MuiAutocomplete-input:first-of-type': {
            paddingLeft: 10,
            paddingTop: 0,
            paddingBottom: 6,
            height: "26px"
        },
    }
});

interface EventSelectorProps {
    options: Event[],
    callback: Function,
    style: object
};

const EventSelector: React.FC<EventSelectorProps> = ({options, callback, style = undefined}) => {
    return (
            <StyledBigAutocomplete
                onChange={(event, value) => {callback(value)}}
                options={options.map((event) => event.description)}
                style={style}
                renderInput={(params) => {
                    return (
                        <TextField
                            {...params}
                            variant="outlined"
                            fullWidth
                        />
                    );
                }}
            />
    );
}

export default EventSelector;