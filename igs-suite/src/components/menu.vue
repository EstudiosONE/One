<template lang="pug">
#menu
	.options
		router-link(to="/" exact tag="div").button
			one-icons-home.icon
		router-link(to="/hotel" tag="div").button
			one-icons-hotel.icon
		router-link(to="/restaurant" tag="div").button
			one-icons-restaurant.icon
		router-link(to="/management" tag="div").button
			one-icons-management.icon
</template>

<script>
export default {}
</script>

<style scoped lang="scss">
@import 'src/styles/colors.scss';
.options {
    .button {
        border-radius: 0 24px 24px 0;
        height: 48px;
        width: 72px;
        margin: 12px 0;
				position: relative;
        .icon {
            fill: $clr-grey-600;
            width: 24px;
            height: 24px;
            padding: 12px 24px;
        }
    }
    .button:hover {
        background-color: $clr-grey-50;
    }
    .router-link-active {
        background-color: $clr-blue-50;
        .icon {
            fill: $clr-blue;
        }
    }
    .router-link-active:hover {
        background-color: $clr-blue-50;
    }
}
</style>
