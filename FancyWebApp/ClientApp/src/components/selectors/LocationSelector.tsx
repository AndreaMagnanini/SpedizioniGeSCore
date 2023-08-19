import React from 'react'
import Autocomplete from '@mui/material/Autocomplete';
import { styled } from '@mui/material';
import { TextField } from '@material-ui/core';
import { Location } from '../../abstractions/Location';

const StyledSmallAutocomplete = styled(Autocomplete)({
    "& .MuiInputLabel-outlined:not(.MuiInputLabel-shrink)": {
        transform: "translate(100px, 20px) scale(1);"
    },
    "& .MuiAutocomplete-inputRoot": {
        '&[class*="MuiOutlinedInput-root"] .MuiAutocomplete-input:first-of-type': {
            paddingLeft: 10,
            paddingTop: 0,
            paddingBottom: 2,
            height: "25px"
        },
    }
});

interface LocationSelectorProps {
    options: Location[],
    callback: Function,
    style: object
};

const LocationSelector: React.FC<LocationSelectorProps> = ({options, callback, style = undefined}) => {
    return (
        <StyledSmallAutocomplete
            onChange={(event, value) => {callback(value)}}
            options={options.map((location) => location.name)}
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

export default LocationSelector;