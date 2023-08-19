import React from 'react'
import Autocomplete from '@mui/material/Autocomplete';
import { styled } from '@mui/material';
import { TextField } from '@material-ui/core';
import { Port } from '../../abstractions/Port';

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

interface PortSelectorProps {
    options: Port[],
    callback: Function,
    style: object
};

const PortSelector: React.FC<PortSelectorProps> = ({options, callback, style = undefined}) => {
    return (
        <StyledSmallAutocomplete
            onChange={(event, value) => {callback(value)}}
            options={options.map((port) => port.name)}
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

export default PortSelector;