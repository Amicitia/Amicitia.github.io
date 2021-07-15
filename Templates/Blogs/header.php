<?php
/**
 * The header for our theme
 *
 * This is the template that displays all of the <head> section and everything up until <div id="content">
 *
 * @link https://developer.wordpress.org/themes/basics/template-files/#template-partials
 *
 * @package Justread
 */

?>
<!doctype html>
<html class="no-js" <?php language_attributes(); ?>>
<head>
	<meta charset="<?php bloginfo( 'charset' ); ?>">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<link rel="profile" href="http://gmpg.org/xfn/11">
	<!--INDEXHEADER-->
	<?php wp_head(); ?>
</head>
<!--INDEXAFTERHEADER-->
<center>
	<a href="https://shrinefox.com/forum">
		<img src="https://amicitia.github.io/images/logo.svg" style="width:150px;height:150px;">
		<br><h1>ShrineFox</h1>
		<h2>Blog</h2>
	</a>
</center>
</div>
<!--INDEXBEFORECONTENT-->
<?php wp_body_open(); ?>
<div id="page" class="site">
	<a class="skip-link screen-reader-text" href="#content"><?php esc_html_e( 'Skip to content', 'justread' ); ?></a>

	<div class="form-wrapper" id="form-wrapper">
		<button
			class="search-close" id="search-close"
			<?php if ( justread_is_amp() ) : ?>
				on="tap:form-wrapper.toggleClass( class='is-visible', force=false )"
			<?php endif; ?>
		>&times;</button>
		<?php get_search_form(); ?>
	</div>

	<header id="masthead" class="site-header">
		<div class="navbar">
			<div class="site-branding">
				<?php
				the_custom_logo();
				if ( is_front_page() && is_home() ) :
					?>
					<h1 class="site-title"><a href="<?php echo esc_url( home_url( '/' ) ); ?>" rel="home"><?php bloginfo( 'name' ); ?></a></h1>
					<?php
				else :
					?>
					<p class="site-title"><a href="<?php echo esc_url( home_url( '/' ) ); ?>" rel="home"><?php bloginfo( 'name' ); ?></a></p>
					<?php
				endif;

				$description = get_bloginfo( 'description', 'display' );
				if ( $description || is_customize_preview() ) :
					?>
					<p class="site-description"><?php echo wp_kses_post( $description ); ?></p>
				<?php endif; ?>
			</div><!-- .site-branding -->

			<nav id="site-navigation" class="main-navigation">
				<?php
				wp_nav_menu(
					array(
						'theme_location' => 'menu-1',
						'menu_id'        => 'primary-menu',
						'menu_class'     => 'menu',
						'container'      => '',
					)
				);
				?>
			</nav><!-- #site-navigation -->
		</div>
		<div class="social-icons">
			<?php
			if ( function_exists( 'jetpack_social_menu' ) ) {
				jetpack_social_menu();
			}
			?>
			<button
				class="search-toggle" aria-controls="form-wrapper" aria-expanded="false"
				<?php if ( justread_is_amp() ) : ?>
					on="tap:form-wrapper.toggleClass( class='is-visible' )"
				<?php endif; ?>
			><?php echo justread_get_svg( array( 'icon' => 'search' ) ); // wpcs xss: ok. ?></button>
			<button id="site-navigation-open" class="menu-toggle" aria-controls="primary-menu" aria-expanded="false"><?php esc_html_e( 'Menu', 'justread' ); ?></button>
		</div>
	</header><!-- #masthead -->

	<div id="content" class="site-content">
