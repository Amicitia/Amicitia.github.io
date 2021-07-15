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
	<script src="https://shrinefox.com/js/jquery-3.3.1.min.js"></script>
<link href="https://fonts.googleapis.com/css2?family=Lato:wght@300;400&display=swap" rel="stylesheet">
<script src="https://kit.fontawesome.com/4c3075832a.js" crossorigin="anonymous"></script>
<script data-ad-client="ca-pub-9519592525056753" async src="https://pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
<link href="https://shrinefox.com/favicon.ico" rel="shortcut icon" type="image/x-icon" />
<link href="https://shrinefox.com/css/amicitia.css" rel="stylesheet" type="text/css">
<script src="https://shrinefox.com/js/bubbles.js"></script>
<script src="https://shrinefox.com/js/clipboard.js"></script>
<script src="https://shrinefox.com/js/showhide.js"></script>
<script src="https://shrinefox.com/js/navigation.js"></script>
<script type="text/javascript" src="https://shrinefox.com/js/FeedEk.min.js"></script>
<script type="text/javascript" src="https://shrinefox.com/js/jscolor.js"></script>
<link rel="stylesheet" href="https://shrinefox.com/css/css3menu.css" type="text/css" />
<style type="text/css">._css3m {display: none;}</style>
	<?php wp_head(); ?>
</head>
<body style="background: linear-gradient(120deg, var(--gradient1) 0%, var(--gradient2) 100%) fixed;">
    <!--Copied Message-->
    <div class="copied">Copied to Clipboard</div>
    <div class="flex">
        <!--TopRow-->
        <div class="row top">
            <!--Navbar-->
            <div class="navbar">
                <input type="checkbox" id="css3menu-switcher" class="c3m-switch-input">
                <ul id="css3menu0" class="topmenu">
                    <li class="switch"><label onclick="" for="css3menu-switcher"></label></li>
                    <li class="topmenu"><a href="https://shrinefox.com" style="height:37px;line-height:37px;"><i class="fa fa-home" aria-hidden="true"></i> Home</a></li>
                    <li class="toproot">
                        <a style="height:37px;line-height:37px;"><span><i class="fa fa-cube" aria-hidden="true"></i> Resources <i class="fas fa-chevron-down" style="font-size: 6pt;"></i></span></a>
                        <ul>
                            <li><a href="https://amicitia.github.io"><i class="fa fa-download" aria-hidden="true"></i> Browse Mods & Tools</a></li>
                            <li><a href="https://shrinefox.com/PatchCreator"><i class="fa fa-check-square" aria-hidden="true"></i> RPCS3 Patch Creator</a></li>
                            <li><a href="https://shrinefox.com/UpdateCreator"><i class="fa fa-check-square" aria-hidden="true"></i> PS4 Patch Creator</a></li>
                            <li><a href="https://shrinefox.com/textsearch"><i class="fab fa-searchengin" aria-hidden="true"></i> Text Search</a></li>
                            <li><a href="https://amicitia.github.io/files"><i class="fa fa-folder-open" aria-hidden="true"></i> Files</a></li>
                            <li><a href="https://amicitia.github.io/docs/flowscript"><i class="fa fa-file-code" aria-hidden="true"></i> Flowscript Docs</a></li>
                        </ul>
                    </li>
                    <li class="toproot">
                        <a style="height:37px;line-height:37px;"><span><i class="fa fa-users" aria-hidden="true"></i> Community <i class="fas fa-chevron-down" style="font-size: 6pt;"></i></span></a>
                        <ul>
                            <li><a href="https://shrinefox.com/forum"><i class="fa fa-comments" aria-hidden="true"></i> Forum</a></li>
                            <li><a href="https://shrinefox.com/wiki"><i class="fa fa-book" aria-hidden="true"></i> Wiki</a></li>
                            <li><a href="https://discord.gg/9USHGmB"><i class="fab fa-discord" aria-hidden="true"></i> Discord</a></li>
                        </ul>
                    </li>
                    <li class="toproot" style="margin-left: 10px; position: relative;">
                        <a id="sidebartoggle">
                            <i class="fa fa-user-circle"></i> Profile
                        </a>
                        <ul style="padding: 0 !important; -webkit-box-shadow: none !important; box-shadow: none !important; ">
                            <div>
                                <div class="sidebar">
                                    <div class="component">
                                        <div class="contents">
                                            <!--Notifications-->
                                            <li>
                                                <a href="https://shrinefox.com/forum/ucp.php">
                                                    <div class="item">
                                                        <i class="fa fa-address-card"></i> &nbsp;Account Settings
                                                    </div>
                                                </a>
                                            </li>
                                            <li>
                                                <a href="https://shrinefox.com/forum/ucp.php?i=pm&folder=inbox">
                                                    <div class="item">
                                                        <i class="fa fa-envelope"></i> &nbsp;Inbox
                                                    </div>
                                                </a>
                                            </li>
                                            <li>
                                                <a href="https://shrinefox.com/forum/search.php">
                                                    <div class="item">
                                                        <i class="fa fa-search"></i> &nbsp;Search
                                                    </div>
                                                </a>
                                            </li>
                                            <li>
                                                <a href="https://shrinefox.com/forum/search.php?search_id=egosearch">
                                                    <div class="item">
                                                        <i class="fa fa-sticky-note"></i> &nbsp;Your Posts
                                                    </div>
                                                </a>
                                            </li>
                                            <li>
                                                <a href="https://shrinefox.com/forum/search.php?search_id=active_topics">
                                                    <div class="item">
                                                        <i class="fa fa-star"></i> &nbsp;Active Threads
                                                    </div>
                                                </a>
                                            </li>
                                        
                                    
                                
                            </div>
                        </ul>
                    </li>
                    <li class="toproot">
                        <a style="height:37px;line-height:37px;"><span><i class="fa fa-question-circle" aria-hidden="true"></i> About <i class="fas fa-chevron-down" style="font-size: 6pt;"></i></span></a>
                        <ul>
                            <li><a href="https://shrinefox.com/forum/app.php/faqpage"><i class="fa fa-comment-dots" aria-hidden="true"></i> FAQs</a></li>
                            <li><a href="https://shrinefox.com/about"><i class="fa fa-address-book" aria-hidden="true"></i> Credits</a></li>
                            <li><a href="https://youtube.com/c/ShrineFox"><i class="fab fa-youtube" aria-hidden="true"></i> YouTube</a></li>
                            <li><a href="https://twitter.com/AmicitiaTeam"><i class="fab fa-twitter" aria-hidden="true"></i> Twitter</a></li>
                        </ul>
                    </li>
                    <li class="toproot">
                        <a style="height:37px;line-height:37px;"><span><i class="fa fa-newspaper" aria-hidden="true"></i> Articles <i class="fas fa-chevron-down" style="font-size: 6pt;"></i></span></a>
                        <ul>
                            <li><a href="https://shrinefox.com/news"><i class="fa fa-newspaper" aria-hidden="true"></i> News</a></li>
                            <li><a href="https://shrinefox.com/guides"><i class="fa fa-graduation-cap" aria-hidden="true"></i> Guides</a></li>
                            <li><a href="https://shrinefox.com"><i class="fab fa-wordpress" aria-hidden="true"></i> Blog</a></li>
                        </ul>
                    </li>
                </ul>
            </div>
            <!--Header-->
            <div class="header">
                <canvas id="bgCanvas" width="715" height="722" style=""></canvas>
                <div class="header-inner">
                    <!--Title-->
<center>
	<a href="https://shrinefox.com/forum">
		<img src="https://amicitia.github.io/images/logo.svg" style="width:150px;height:150px;">
		<br><h1>Amicitia</h1>
		<h2>News</h2>
	</a>
</center>
</div>
            <!--Waves-->
    <svg class="waves" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" viewBox="0 24 150 28" preserveAspectRatio="none" shape-rendering="auto">
        <defs>
            <path id="gentle-wave" d="M-160 44c30 0 58-18 88-18s 58 18 88 18 58-18 88-18 58 18 88 18 v44h-352z"></path>
        </defs>
        <g class="parallax">
            <use xlink:href="#gentle-wave" x="48" y="0"></use>
            <use xlink:href="#gentle-wave" x="48" y="3"></use>
            <use xlink:href="#gentle-wave" x="48" y="5"></use>
            <use xlink:href="#gentle-wave" x="48" y="7"></use>
        </g>
    </svg>
</div>
<!--Waves End-->
<!--Header End-->
    </div>
<!--Navbar End-->

<!--Middle-->
<div class="row middle">
    <!--Page Body-->
    <div class="content">
        <div class="">
            <!--Main Page Content-->
            <table id="">
                <tr>
                    <td style="vertical-align:top;">
                        
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
